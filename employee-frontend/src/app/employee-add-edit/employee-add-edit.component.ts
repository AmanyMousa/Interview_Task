import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { 
  FormBuilder, 
  FormGroup, 
  Validators, 
  ReactiveFormsModule 
} from '@angular/forms';
import { 
  MatDialogRef, 
  MAT_DIALOG_DATA, 
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule, MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeService } from '../core/services/employee.service';

@Component({
  selector: 'app-employee-add-edit',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  templateUrl: './employee-add-edit.component.html',
  styleUrls: ['./employee-add-edit.component.css']
})
export class EmployeeAddEditComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private dialogRef: MatDialogRef<EmployeeAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private snackBar: MatSnackBar
  ) {
    this.employeeForm = this.fb.group({
      id: 0,
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      position: ['']
    });
  }

  ngOnInit(): void {
    if (this.data) {
      this.employeeForm.patchValue(this.data);
    }
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      if (this.data) {
        this.employeeService.updateEmployee(this.data.id, this.employeeForm.value)

          .subscribe({
            next: () => {
              this.showSnackBar('Employee updated successfully');
              this.dialogRef.close(true);
            },
            error: (err) => {
              console.log(this.data.id)
              console.log(this.data.id, this.employeeForm.value);
              this.showSnackBar('Error updating employee');
            }
          });
      } else {
        this.employeeService.addEmployee(this.employeeForm.value)
          .subscribe({
            next: () => {
              this.showSnackBar('Employee added successfully');
              this.dialogRef.close(true);
            },
            error: (err) => {
              this.showSnackBar('Error adding employee');
            }
          });
      }
    }
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }

  private showSnackBar(message: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
      verticalPosition: 'top'
    });
  }
}