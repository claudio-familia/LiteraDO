export interface SignInModel {
    Id: number;
    CountryId: number;
    UserName: string;
    Password: string;
    Email: string;
    FirstName: string;
    LastName: string;
    BirthDate: Date;
    Gender: string;
    TargetPreference: number;
}