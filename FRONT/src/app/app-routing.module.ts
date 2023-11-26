import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ListarUsuarioComponent } from "./pages/usuario/listar-usuario/listar-usuario.component";
import { CadastrarUsuarioComponent } from "./pages/usuario/cadastrar-usuario/cadastrar-usuario.component";
import { AlterarUsuarioComponent } from "./pages/usuario/alterar-usuario/alterar-usuario.component";

import { ListarFichaComponent } from "./pages/ficha/listar-ficha/listar-ficha.component";
import { CadastrarFichaComponent } from "./pages/ficha/cadastrar-ficha/cadastrar-ficha.component";
import { AlterarFichaComponent } from "./pages/ficha/alterar-ficha/alterar-ficha.component";

import { ListarCampanhaComponent } from "./pages/campanha/listar-campanha/listar-campanha.component";
import { CadastrarCampanhaComponent } from "./pages/campanha/cadastrar-campanha/cadastrar-campanha.component";
import { AlterarCampanhaComponent } from "./pages/campanha/alterar-campanha/alterar-campanha.component";

import { ListarClasseComponent } from "./pages/classe/listar-classe/listar-classe.component";
import { CadastrarClasseComponent } from "./pages/classe/cadastrar-classe/cadastrar-classe.component";
import { AlterarClasseComponent } from "./pages/classe/alterar-classe/alterar-classe.component";

const routes: Routes = [
  // Rotas para Usuario
  {
    path: "usuario",
    component: ListarUsuarioComponent,
  },
  {
    path: "usuario/cadastrar",
    component: CadastrarUsuarioComponent,
  },
  {
    path: "usuario/alterar/:id",
    component: AlterarUsuarioComponent,
  },
  // Rotas para Ficha
  {
    path: "ficha",
    component: ListarFichaComponent,
  },
  {
    path: "ficha/cadastrar",
    component: CadastrarFichaComponent,
  },
  {
    path: "ficha/alterar/:id",
    component: AlterarFichaComponent,
  },
  // Rotas para Campanha
  {
    path: "campanha",
    component: ListarCampanhaComponent,
  },
  {
    path: "campanha/cadastrar",
    component: CadastrarCampanhaComponent,
  },
  {
    path: "campanha/alterar/:id",
    component: AlterarCampanhaComponent,
  },
  // Rotas para Classe
  {
    path: "classe",
    component: ListarClasseComponent,
  },
  {
    path: "classe/cadastrar",
    component: CadastrarClasseComponent,
  },
  {
    path: "classe/alterar/:id",
    component: AlterarClasseComponent,
  },
  // ... outras rotas se necessário
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
