import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Classe } from "src/app/models/classe.models";

@Component({
  selector: "app-listar-classe",
  templateUrl: "./listar-classe.component.html",
  styleUrls: ["./listar-classe.component.css"],
})
export class ListarClasseComponent {
  colunasTabela: string[] = ["classeId", "nome", "atributoBonus", "alterar", "deletar"];
  classes: Classe[] = [];

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  // Método executado ao abrir o componente
  ngOnInit(): void {
    this.client
      .get<Classe[]>("https://localhost:7108/api/classe/listar")
      .subscribe({
        next: (classes) => {
          this.classes = classes;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(classeId: number) {
    this.client
      .delete<Classe[]>(`https://localhost:7108/api/classe/deletar/${classeId}`)
      .subscribe({
        next: (classes) => {
          this.classes = classes;
          this.snackBar.open("Classe deletada com sucesso!", "Sistema", {
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
