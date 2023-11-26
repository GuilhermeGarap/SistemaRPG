import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Usuario } from "src/app/models/usuario.models";

@Component({
  selector: "app-cadastrar-usuario",
  templateUrl: "./cadastrar-usuario.component.html",
  styleUrls: ["./cadastrar-usuario.component.css"],
})
export class CadastrarUsuarioComponent {
  nome: string = "";
  fichas: any[] = []; // Certifique-se de ajustar o tipo correto para suas Fichas

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  cadastrar(): void {
    let novoUsuario: Usuario = {
      nome: this.nome,
      fichas: this.fichas,
      usuarioId: 0,
    };

    this.client
      .post<Usuario>("https://localhost:7108/api/usuario/cadastrar", novoUsuario)
      .subscribe({
        next: (usuario) => {
          this.snackBar.open("Usuário cadastrado com sucesso!", "Sistema", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/usuario/listar"]); // Ajuste o caminho conforme necessário
        },
        error: (erro) => {
          console.log(erro);
          // Adicione tratamento de erro conforme necessário
        },
      });
  }
}
