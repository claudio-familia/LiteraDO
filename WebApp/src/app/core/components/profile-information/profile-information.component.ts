import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Country } from 'src/app/shared/models/country';
import { CountryService } from 'src/app/shared/services/country.service';
import { AlertService } from 'src/app/core/services/alert.service';
import { AuthService } from 'src/app/features/auth/services/auth.service';
import { UserService } from 'src/app/features/auth/services/user.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'literado-profile-information',
  templateUrl: './profile-information.component.html',
  styleUrls: ['./profile-information.component.scss']
})
export class ProfileInformationComponent implements OnInit {
  countries: Country[] = []
  currentUserId: string = '';
  constructor(
    private fb: FormBuilder, 
    private userService: UserService, 
    private alertService: AlertService,
    private countryService: CountryService,
    private dialog: MatDialog ) {}

  async ngOnInit(): Promise<void> {
    this.countries = await this.countryService.get().toPromise() || [];
    this.userService.getInformation().subscribe(res => {
        this.currentUserId = res.id;
        this.userForm.setValue({
            username: res.userName,
            birthdate: res.birthDate,
            countryId: res.countryId,
            email: res.email,
            firstName: res.firstName,
            lastName: res.lastName,
            gender: res.gender,
            targetPreference: res.targetPreference
        });
    });
  
  }
  userForm = this.fb.group({
    username: [null, Validators.required],
    firstName: [null, Validators.required],
    lastName: [null],
    email: [null, [Validators.required, Validators.email]],
    birthdate: null,
    gender: [null, Validators.required],
    countryId: [null, Validators.required],
    targetPreference: [null]
  });

  getControl(controlName: 
    "username" | 
    "firstName" |
    "lastName" |
    "email" |
    "gender" |
    "countryId" |
    "birthdate" |
    "email" |
    "targetPreference"): FormControl {
    return this.userForm.controls[controlName];
  }

  close(): void {
    this.dialog.closeAll();
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      const values = this.userForm.value as any;
      this.userService.updateProfile(values).subscribe(() => {
        this.alertService.ModalNotification("Correcto", "Información actualizada exitosamente", "success").then(async () => {
          this.close();
        });
      });
    }
  }
}
