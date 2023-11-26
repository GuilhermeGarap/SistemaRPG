import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Usuario } from "src/app/models/usuario.models";
import { Ficha } from "src/app/models/ficha.models";

@Component({
  selector: "app-alterar-usuario",
  templateUrl: "./alterar-usuario.component.html",
  styleUrls: ["./alterar-usuario.component.css"],
})
export class AlterarUsuarioComponent {
  usuarioId: number | null = null;
  nome: string = "";
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
        this.client.get<Usuario>(`https://localhost:7108/api/usuario/buscar/${id}`).subscribe({
          next: (usuario) => {
            this.usuarioId = usuario.usuarioId;
            this.nome = usuario.nome;
            this.fichas = usuario.fichas || [];
          },
          error: (erro) => {
            console.log(erro);
          },
        });
      },
    });
  }

  alterar(): void {
    let usuario: Usuario = {
      nome: this.nome,
      fichas: this.fichas,
      usuarioId: this.usuarioId !== null ? this.usuarioId : 0,
    };
  
    this.client.put<Usuario>(`https://localhost:7108/api/usuario/alterar/${this.usuarioId}`, usuario).subscribe({
      next: (usuario) => {
        this.snackBar.open("Usuário alterado com sucesso!", "Sistema", {
          duration: 1500,
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        // Ajuste o caminho conforme necessário
        this.router.navigate(["pages/usuario/listar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }    
}
