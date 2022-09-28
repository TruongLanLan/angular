import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name:'pipeImage'
})

export class PipeImage implements PipeTransform {
    transform(value: unknown, ...args: unknown[]): string {

        if (value == null)
          value = "Assets/Images/no_img.jpg";
        else if ((value as string).indexOf("data:image/png;base64,") >= 0 
        || (value as string).indexOf("data:image/jpg;base64,") >= 0 
        || (value as string).indexOf("data:image/jpeg;base64,") >= 0)
          return value as string;
        return `http://localhost:5288/` + value;
      }
    
}