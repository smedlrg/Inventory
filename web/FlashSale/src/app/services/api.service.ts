import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class apiService {

    constructor(private httpClient: HttpClient){

    }

    getItems() : Observable<any> {
        return this.httpClient.get("https://localhost:7164/Items");
    }

    getTimer() : Observable<any> {
        return this.httpClient.get("https://localhost:7164/Timer");
    }

    endTimer() :Observable<any> {
        return this.httpClient.post("https://localhost:7164/Timer",null);
    }
}