import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { User, Socials } from './models/user.model';
import { UserService } from './services/user.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipEditedEvent } from '@angular/material/chips';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Inimco Developer Excercise';

  form!: FormGroup;
  skills: string[] = ["social", "fun", "coach"];
  socials: string[] = ["Twitter", "Linkedin", "Facebook"];

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit(): void
  {    
    this.form = this.formBuilder.group({
      firstName: ["John", Validators.required],
      lastName: ["Doe", Validators.required],
      socialSkills: [this.skills, Validators.required],

      socialAccountsTemp: this.formBuilder.group({
        twitter: [null],
        linkedin: [null],
        facebook: [null],
      })
    });
  }

  onSubmit(data: any) {
    data.socialSkills = this.skills;

    let temp: Socials[] = [];

    for (var index = 0; index < this.socials.length; index++) {
      if (data.socialAccountsTemp[this.socials[index].toLowerCase()] != undefined) {
        temp.push(new Socials(this.socials[index], data.socialAccountsTemp[this.socials[index].toLowerCase()]))
      }
    }

    delete data.socialAccountsTemp;
    data.socialAccounts = temp;

    this.add(data);
  }

  add(user: User) {
    this.userService.add(user).subscribe(response => {
      console.log(response);
    })
  }
}
