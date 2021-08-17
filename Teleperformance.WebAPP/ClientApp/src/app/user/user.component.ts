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

//Define el tipo de identificación
interface IdentificationType {
  Name: string;
}

//Define el municipio
interface Municipio {
  id: string;
  name: string;
}

//Define el contacto
interface Contact {
  via: string;
  nro1: string;
  letra1: string;
  nr2: string;
  letra2: string;
  nroyComplementos: string;
  direccion: string;
  municipio: Municipio;
  telefono1: string;
}

//Define el usuario
interface User {
  id: string;
  identificationType: IdentificationType;
  identificationNumber: string
  companyName: string;
  firstName: string;
  secondName: string;
  fistLastName: string;
  contact: Contact;
}

//Define la respuesta
interface response {
  data: User[];
}
