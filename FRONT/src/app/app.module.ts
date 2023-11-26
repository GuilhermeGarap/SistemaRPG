import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatListModule } from "@angular/material/list";
import { MatTableModule } from "@angular/material/table";
import { MatCardModule } from "@angular/material/card";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatChipsModule } from '@angular/material/chips';
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ListarUsuarioComponent } from "./pages/usuario/listar-usuario/listar-usuario.component";
import { CadastrarUsuarioComponent } from "./pages/usuario/cadastrar-usuario/cadastrar-usuario.component";
import { ListarFichaComponent } from "./pages/ficha/listar-ficha/listar-ficha.component";
import { CadastrarFichaComponent } from "./pages/ficha/cadastrar-ficha/cadastrar-ficha.component";
import { ListarClasseComponent } from "./pages/classe/listar-classe/listar-classe.component";
import { CadastrarClasseComponent } from "./pages/classe/cadastrar-classe/cadastrar-classe.component";
import { ListarCampanhaComponent } from "./pages/campanha/listar-campanha/listar-campanha.component";
import { CadastrarCampanhaComponent } from "./pages/campanha/cadastrar-campanha/cadastrar-campanha.component";
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
  declarations: [
    AppComponent,
    ListarUsuarioComponent,
    CadastrarUsuarioComponent,
    ListarFichaComponent,
    CadastrarFichaComponent,
    ListarClasseComponent,
    CadastrarClasseComponent,
    ListarCampanhaComponent,
    CadastrarCampanhaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatChipsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatCardModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    MatSnackBarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
