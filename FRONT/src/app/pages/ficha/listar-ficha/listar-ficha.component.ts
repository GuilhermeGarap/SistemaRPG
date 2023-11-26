import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Ficha } from "src/app/models/ficha.models";

@Component({
  selector: "app-listar-ficha",
  templateUrl: "./listar-ficha.component.html",
  styleUrls: ["./listar-ficha.component.css"],
})
export class ListarFichaComponent {
  colunasTabela: string[] = ["fichaId", "nome", "vida", "estamina", "alterar", "deletar"];
  fichas: Ficha[] = [];

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  // Método executado ao abrir o componente
  ngOnInit(): void {
    this.client
      .get<Ficha[]>("https://localhost:7108/api/ficha/listar")
      .subscribe({
        next: (fichas) => {
          this.fichas = fichas;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(fichaId: number) {
    this.client
      .delete<Ficha[]>(`https://localhost:7108/api/ficha/deletar/${fichaId}`)
      .subscribe({
        next: (fichas) => {
          this.fichas = fichas;
          this.snackBar.open("Ficha deletada com sucesso!", "Sistema", {
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
