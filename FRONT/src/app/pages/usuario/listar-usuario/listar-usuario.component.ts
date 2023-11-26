import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Usuario } from "src/app/models/usuario.models";

@Component({
  selector: "app-listar-usuario",
  templateUrl: "./listar-usuario.component.html",
  styleUrls: ["./listar-usuario.component.css"],
})
export class ListarUsuarioComponent {
  colunasTabela: string[] = ["usuarioId", "nome", "fichas", "alterar", "deletar"];
  usuarios: Usuario[] = [];

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  // Método executado ao abrir o componente
  ngOnInit(): void {
    this.client
      .get<Usuario[]>("https://localhost:7108/api/usuario/listar")
      .subscribe({
        next: (usuarios) => {
          this.usuarios = usuarios;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(usuarioId: number) {
    this.client
      .delete<Usuario[]>(`https://localhost:7108/api/usuario/deletar/${usuarioId}`)
      .subscribe({
        next: (usuarios) => {
          this.usuarios = usuarios;
          this.snackBar.open("Usuário deletado com sucesso!", "Sistema", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}
