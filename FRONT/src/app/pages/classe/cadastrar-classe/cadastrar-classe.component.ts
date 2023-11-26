import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Classe } from "src/app/models/classe.models";

@Component({
  selector: "app-cadastrar-classe",
  templateUrl: "./cadastrar-classe.component.html",
  styleUrls: ["./cadastrar-classe.component.css"],
})
export class CadastrarClasseComponent {
  nome: string = "";
  atributoBonus: string | null = "";

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  cadastrar(): void {
    let novaClasse: Classe = {
        nome: this.nome,
        atributoBonus: this.atributoBonus,
        classeId: 0
    };

    this.client
      .post<Classe>("https://localhost:7108/api/classe/cadastrar", novaClasse)
      .subscribe({
        next: (classe) => {
          this.snackBar.open("Classe cadastrada com sucesso!", "Sistema", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/classe/listar"]); // Ajuste o caminho conforme necessário
        },
        error: (erro) => {
          console.log(erro);
          // Adicione tratamento de erro conforme necessário
        },
      });
  }
}
