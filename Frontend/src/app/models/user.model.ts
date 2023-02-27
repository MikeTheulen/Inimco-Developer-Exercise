export class User {
  firstName: string;
  lastName: string;
  socialSkills: string[];
  socialAccounts: Socials[];

  constructor(firstName: string, lastName: string, socialSkills: string[], socialAccounts: Socials[])
  {
    this.firstName = firstName;
    this.lastName = lastName;
    this.socialSkills = socialSkills;
    this.socialAccounts = socialAccounts;
  }
}

export class Socials {
  type: string;
  address: string;

  constructor(type: string, address: string) {
    this.type = type;
    this.address = address;
  }
}
