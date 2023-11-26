import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Classe } from "src/app/models/classe.models";

@Component({
  selector: "app-alterar-classe",
  templateUrl: "./alterar-classe.component.html",
  styleUrls: ["./alterar-classe.component.css"],
})
export class AlterarClasseComponent {
  classeId: number | null = null;
  nome: string = "";
  atributoBonus: string | null = null;

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
        this.client.get<Classe>(`https://localhost:7108/api/classe/buscar/${id}`).subscribe({
          next: (classe) => {
            this.classeId = classe.classeId;
            this.nome = classe.nome;
            this.atributoBonus = classe.atributoBonus ?? null;
          },
          error: (erro) => {
            console.log(erro);
          },
        });
      },
    });
  }

  alterar(): void {
    let classe: Classe = {
      nome: this.nome,
      atributoBonus: this.atributoBonus !== undefined ? this.atributoBonus : null,
      classeId: this.classeId !== null ? this.classeId : 0
    };
  
    this.client.put<Classe>(`https://localhost:7108/api/classe/alterar/${this.classeId}`, classe).subscribe({
      next: (classe) => {
        this.snackBar.open("Classe alterada com sucesso!", "Sistema", {
          duration: 1500,
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        // Ajuste o caminho conforme necessário
        this.router.navigate(["pages/classe/listar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }    
}
