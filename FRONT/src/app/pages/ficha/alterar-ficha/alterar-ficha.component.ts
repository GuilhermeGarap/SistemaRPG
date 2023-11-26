import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Ficha } from "src/app/models/ficha.models";
import { Classe } from "src/app/models/classe.models";
import { Usuario } from "src/app/models/usuario.models";
import { Campanha } from "src/app/models/campanha.models";

@Component({
  selector: "app-alterar-ficha",
  templateUrl: "./alterar-ficha.component.html",
  styleUrls: ["./alterar-ficha.component.css"],
})
export class AlterarFichaComponent {
  fichaId: number | null = null;
  nome: string = "";
  vida: number | null = null;
  estamina: number | null = null;
  desAparencia: string = "";
  historia: string = "";
  vigor: number = 0;
  presenca: number = 0;
  sabedoria: number = 0;
  forca: number = 0;
  agilidade: number = 0;
  classeId: number | null = null;
  usuarioId: number | null = null;
  campanhaId: number | null = null;
  classes: Classe[] = [];
  usuarios: Usuario[] = [];
  campanhas: Campanha[] = [];

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
        this.client.get<Ficha>(`https://localhost:7108/api/ficha/buscar/${id}`).subscribe({
          next: (ficha) => {
            this.fichaId = ficha.fichaId;
            this.nome = ficha.nome;
            this.vida = ficha.vida !== undefined ? ficha.vida : null;
            this.estamina = ficha.estamina !== undefined ? ficha.estamina : null;
            this.desAparencia = ficha.desAparencia;
            this.historia = ficha.historia;
            this.vigor = ficha.vigor;
            this.presenca = ficha.presenca;
            this.sabedoria = ficha.sabedoria;
            this.forca = ficha.forca;
            this.agilidade = ficha.agilidade;
            this.classeId = ficha.classeId;
            this.usuarioId = ficha.usuarioId;
            this.campanhaId = ficha.campanhaId;
          },
          error: (erro) => {
            console.log(erro);
          },
        });
      },
    });

    this.client.get<Classe[]>("https://localhost:7108/api/classe/listar").subscribe({
      next: (classes) => {
        this.classes = classes;
      },
      error: (erro) => {
        console.log(erro);
      },
    });

    this.client.get<Usuario[]>("https://localhost:7108/api/usuario/listar").subscribe({
      next: (usuarios) => {
        this.usuarios = usuarios;
      },
      error: (erro) => {
        console.log(erro);
      },
    });

    this.client.get<Campanha[]>("https://localhost:7108/api/campanha/listar").subscribe({
      next: (campanhas) => {
        this.campanhas = campanhas;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }

  alterar(): void {
    let ficha: Ficha = {
      fichaId: this.fichaId !== null ? this.fichaId : 0,
      nome: this.nome,
      vida: this.vida,
      estamina: this.estamina,
      desAparencia: this.desAparencia,
      historia: this.historia,
      vigor: this.vigor,
      presenca: this.presenca,
      sabedoria: this.sabedoria,
      forca: this.forca,
      agilidade: this.agilidade,
      classeId: this.classeId !== null ? this.classeId : 0,
      usuarioId: this.usuarioId !== null ? this.usuarioId : 0,
      campanhaId: this.campanhaId !== null ? this.campanhaId : 0,
    };

    this.client.put<Ficha>(`https://localhost:7108/api/ficha/alterar/${this.fichaId}`, ficha).subscribe({
      next: (ficha) => {
        this.snackBar.open("Ficha alterada com sucesso!", "Sistema", {
          duration: 1500,
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        // Ajuste o caminho conforme necessário
        this.router.navigate(["pages/ficha/listar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
