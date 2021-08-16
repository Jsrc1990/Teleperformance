import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html'
})
export class UserComponent {

  //Define los usuarios
  public users: User[];

  //Define el usuario
  public CurrentUser: User;

  //Define el constructor
  constructor(private http: HttpClient) {
    http.get<response>('https://localhost:44358/api/user/api/user/consultar').subscribe(result => {
      this.users = result.data;
    }, error => console.error('Error:' + error));
  }

  //Valida si el usuario existe
  public validateUser(id: string) {
    if (id != '') {
      let query: string = '?valor=' + id;
      let url: string = 'https://localhost:44358/api/user/api/user/consultar' + query;
      this.http.get<response>(url).subscribe(result => {
        if (result.data.length == 0) {
          alert('La identificación de la empresa no está registrada');
        }
        else {
          this.CurrentUser = result.data[0];
        }
      }, error => console.error('Error:' + error));
    }
  }




}

//export class ServiceService {

//  constructor(private http: HttpClient) { }
//  httpOptions = {
//    headers: new HttpHeaders({
//      'Content-Type': 'application/json'
//    })
//  }
//  getData() {

//    return this.http.get('/api/Employee');  //https://localhost:44352/ webapi host url  
//  }

//  postData(formData) {
//    return this.http.post('/api/Employee', formData);
//  }

//  putData(id, formData) {
//    return this.http.put('/api/Employee/' + id, formData);
//  }
//  deleteData(id) {
//    return this.http.delete('/api/Employee/' + id);
//  }

//}

interface IdentificationType {
  Name: string;
}

interface User {
  Id: string;
  IdentificationType: IdentificationType;
  IdentificationNumber: string
  CompanyName: string;
  FirstName: string;
  SecondName: string;
  FistLastName: string;
}

interface response {
  data: User[];
}

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<response>('https://localhost:44358/api/user/api/user/consultar').subscribe(result => {
  //    this.users = result.data;
  //  }, error => console.error('Error:' + error));
  //}
