import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Ficha } from "src/app/models/ficha.models";
import { Classe } from "src/app/models/classe.models";
import { Usuario } from "src/app/models/usuario.models";
import { Campanha } from "src/app/models/campanha.models";

@Component({
  selector: "app-cadastrar-ficha",
  templateUrl: "./cadastrar-ficha.component.html",
  styleUrls: ["./cadastrar-ficha.component.css"],
})
export class CadastrarFichaComponent {
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
  classeId: number = 0;
  usuarioId: number = 0;
  campanhaId: number = 0;

  classes: Classe[] = [];
  usuarios: Usuario[] = [];
  campanhas: Campanha[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    // Carregar dados necessários para dropdowns, como classes, usuários e campanhas
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

  cadastrar(): void {
    let novaFicha: Ficha = {
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
      classeId: this.classeId,
      usuarioId: this.usuarioId,
      campanhaId: this.campanhaId,
      fichaId: 0, // Valor padrão para um novo cadastro
    };

    this.client.post<Ficha>("https://localhost:7108/api/ficha/cadastrar", novaFicha).subscribe({
      next: (ficha) => {
        this.snackBar.open("Ficha cadastrada com sucesso!", "Sistema", {
          duration: 1500,
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        this.router.navigate(["pages/ficha/listar"]); // Ajuste o caminho conforme necessário
      },
      error: (erro) => {
        console.log(erro);
        // Adicione tratamento de erro conforme necessário
      },
    });
  }
}
