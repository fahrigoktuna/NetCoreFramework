import { Injectable } from '@angular/core';


@Injectable(
    {
        providedIn: 'root'
    }
)
export class UtilService {

    constructor(){
      
    }

    formatDate(pDate:Date) : string{
        pDate = new Date(pDate);
        return pDate.toLocaleDateString();
      }

    public  Deserialize(data: string): any
    {
        return JSON.parse(data, UtilService.ReviveDateTime);
    }

    private static ReviveDateTime(key: any, value: any): any 
    {
        if (typeof value === 'string')
        {
            let a = /\/Date\((\d*)\)\//.exec(value);
            if (a)
            {
                return new Date(+a[1]);
            }
        }

        return value;
    }
    

}