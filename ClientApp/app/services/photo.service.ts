import { Injectable } from '@angular/core';
import { Http } from "@angular/http";

@Injectable()
export class PhotoService {

    constructor(private http: Http) { }

    upload(productId, photo) {
        var formData = new FormData();
        formData.append('file', photo);
        return this.http.post(`/api/products/${productId}/photos`, formData)
            .map(res => res.json());
    }

}