import { Component,Input, Inject } from '@angular/core';
import { MatDialog,MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-settings-component',
  templateUrl: './settings.component.html',
})
export class SettingsComponent {
  @Input({ required: true }) isHandset$!: Observable<boolean>;
  constructor(
    public dialogRef: MatDialogRef<SettingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  darkTheme: string = 'light theme';
  onNoClick(): void {
    this.dialogRef.close();
  }
  changeTheme(event: any): void {
    const evt = event as MatSlideToggleChange;

    if(evt.checked){
      document.body.classList.add("dark-theme");
      this.darkTheme = "Dark theme"
   }else{
      document.body.classList.remove("dark-theme");
      this.darkTheme = "light theme"
    }
  }
}
