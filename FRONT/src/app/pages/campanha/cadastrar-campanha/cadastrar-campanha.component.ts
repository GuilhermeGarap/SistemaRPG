import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Campanha } from "src/app/models/campanha.models";

@Component({
  selector: "app-cadastrar-campanha",
  templateUrl: "./cadastrar-campanha.component.html",
  styleUrls: ["./cadastrar-campanha.component.css"],
})
export class CadastrarCampanhaComponent {
  nome: string = "";
  sinopse: string = "";
  fichas: any[] = []; // Certifique-se de ajustar o tipo correto para suas Fichas

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  cadastrar(): void {
    let novaCampanha: Campanha = {
      nome: this.nome,
      sinopse: this.sinopse,
      fichas: this.fichas,
      campanhaId: 0,
    };

    this.client
      .post<Campanha>("https://localhost:7108/api/campanha/cadastrar", novaCampanha)
      .subscribe({
        next: (campanha) => {
          this.snackBar.open("Campanha cadastrada com sucesso!", "Sistema", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/campanha/listar"]); // Ajuste o caminho conforme necessário
        },
        error: (erro) => {
          console.log(erro);
          // Adicione tratamento de erro conforme necessário
        },
      });
  }
}
