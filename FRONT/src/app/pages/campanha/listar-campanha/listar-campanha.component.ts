import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Campanha } from "src/app/models/campanha.models";

@Component({
  selector: "app-listar-campanha",
  templateUrl: "./listar-campanha.component.html",
  styleUrls: ["./listar-campanha.component.css"],
})
export class ListarCampanhaComponent implements OnInit {
  colunasTabela: string[] = ["campanhaId", "nome", "sinopse", "alterar", "deletar"];
  campanhas: Campanha[] = [];

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.client
      .get<Campanha[]>("https://localhost:7108/api/campanha/listar")
      .subscribe({
        next: (campanhas) => {
          this.campanhas = campanhas;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(campanhaId: number) {
    this.client
      .delete<Campanha[]>(`https://localhost:7108/api/campanha/deletar/${campanhaId}`)
      .subscribe({
        next: (campanhas) => {
          this.campanhas = campanhas;
          this.snackBar.open("Campanha deletada com sucesso!", "Sistema", {
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
