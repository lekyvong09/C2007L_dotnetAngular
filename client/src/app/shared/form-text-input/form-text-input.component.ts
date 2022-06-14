import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-form-text-input',
  templateUrl: './form-text-input.component.html',
  styleUrls: ['./form-text-input.component.scss']
})
export class FormTextInputComponent implements OnInit, ControlValueAccessor {
  @ViewChild('input', {static: true}) inputElement: ElementRef | undefined;
  @Input() type = 'text';
  @Input() label = 'string';
  
  constructor(public controlDirective: NgControl) { 
    this.controlDirective.valueAccessor = this;
  }

  ngOnInit(): void {
    /// get value, validator from the input
    const control = this.controlDirective.control;
    const validators = control!.validator ? [control!.validator] : [];
    const asyncValidator = control!.asyncValidator ? [control!.asyncValidator] : [];

    control!.setValidators(validators);
    control!.setAsyncValidators(asyncValidator);
    control!.updateValueAndValidity();
  }


  writeValue(obj: any): void {
    this.inputElement!.nativeElement.value = obj || '';
  }



  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  

  onChange(event: any) {
    /// add function
  }

  onTouched() {
  }
}
