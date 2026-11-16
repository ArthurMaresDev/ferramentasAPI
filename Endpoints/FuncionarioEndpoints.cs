
using Microsoft.EntityFrameworkCore;
using ferramentasAPI.Data;
using ferramentasAPI.Models;


namespace ferramentasAPI.Endpoints;

public static class FuncionarioEndpoints
{
    public static void MapFuncionarioEndpoints(this WebApplication app)
    {
        app.MapPost("/funcionarios", async (Funcionario funcionario, AppDbContext db) =>
        {
            db.Funcionarios.Add(funcionario);

            await db.SaveChangesAsync();

            return Results.Created($"/funcionarios/{funcionario.Id}", funcionario);
        });

        app.MapGet("/funcionarios", async (AppDbContext db) =>
        {
            var funcionarios = await db.Funcionarios
                .Select(f => new
                {
                    f.Id,
                    f.Nome,
                    f.Cargo,
                    Ferramentas = f.Ferramentas.Select(ferramenta => new
                    {
                        ferramenta.Id,
                        ferramenta.Nome,
                        ferramenta.Descricao,
                        ferramenta.Disponivel
                    })
                })
                .ToListAsync();

            return Results.Ok(funcionarios);
        });


        app.MapGet("/funcionarios/{id}", async (int id, AppDbContext db) =>
        {
            var funcionario = await db.Funcionarios.FindAsync(id);

            return funcionario is not null
                ? Results.Ok(funcionario)
                : Results.NotFound();
        });

        app.MapPut("/funcionarios/{id}", async (int id, Funcionario dadosAtualizados, AppDbContext db) =>
        {
            var funcionario = await db.Funcionarios.FindAsync(id);

            if (funcionario is null)
                return Results.NotFound();

            funcionario.Nome = dadosAtualizados.Nome;
            funcionario.Cargo = dadosAtualizados.Cargo;

            await db.SaveChangesAsync();
            return Results.Ok(funcionario);

        });

        app.MapDelete("/funcionarios/{id}", async (int id, AppDbContext db) =>
        {
            var funcionario = await db.Funcionarios
                .Include(f => f.Ferramentas)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario is null)
                return Results.NotFound();

            if (funcionario.Ferramentas.Any())
            {
                return Results.Conflict(new
                {
                    mensagem = "Este funcionário possui ferramentas emprestadas.",
                    ferramentas = funcionario.Ferramentas.Select(f => new
                    {
                        f.Id,
                        f.Nome
                    })
                });
            }

            db.Funcionarios.Remove(funcionario);
            await db.SaveChangesAsync();

            return Results.Ok("Funcionário excluído com sucesso!");
        });
    }
}
