import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Campanha } from "src/app/models/campanha.models";
import { Ficha } from "src/app/models/ficha.models";

@Component({
  selector: "app-alterar-campanha",
  templateUrl: "./alterar-campanha.component.html",
  styleUrls: ["./alterar-campanha.component.css"],
})
export class AlterarCampanhaComponent {
  campanhaId: number | null = null;
  nome: string = "";
  sinopse: string = "";
  fichas: Ficha[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: (parametros) => {
        let { id } = parametros;
        this.client.get<Campanha>(`https://localhost:7108/api/campanha/buscar/${id}`).subscribe({
          next: (campanha) => {
            this.campanhaId = campanha.campanhaId;
            this.nome = campanha.nome;
            this.sinopse = campanha.sinopse;
            this.fichas = campanha.fichas || [];
          },
          error: (erro) => {
            console.log(erro);
          },
        });
      },
    });
  }

  alterar(): void {
    let campanha: Campanha = {
      nome: this.nome,
      sinopse: this.sinopse,
      fichas: this.fichas,
      campanhaId: this.campanhaId !== null ? this.campanhaId : 0,
    };
  
    this.client.put<Campanha>(`https://localhost:7108/api/campanha/alterar/${this.campanhaId}`, campanha).subscribe({
      next: (campanha) => {
        this.snackBar.open("Campanha alterada com sucesso!", "Sistema", {
          duration: 1500,
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        // Ajuste o caminho conforme necessário
        this.router.navigate(["pages/campanha/listar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }    
}
