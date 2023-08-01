import { Component, Inject } from '@angular/core';
import { MatDialog,MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-settings-component',
  templateUrl: './settings.component.html',
})
export class SettingsComponent {
  constructor(
    public dialogRef: MatDialogRef<SettingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
