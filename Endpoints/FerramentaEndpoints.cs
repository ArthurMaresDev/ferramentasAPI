using Microsoft.EntityFrameworkCore;
using ferramentasAPI.Data;
using ferramentasAPI.Models;
using ferramentasAPI.DTOs;

namespace ferramentasAPI.Endpoints;

public static class FerramentaEndpoints
{
    public static void MapFerramentaEndpoints(this WebApplication app)
    {
        app.MapPost("/ferramentas", async (Ferramenta ferramenta, AppDbContext db) =>
        {
            db.Ferramentas.Add(ferramenta);

            await db.SaveChangesAsync();

            return Results.Created($"/ferramentas/{ferramenta.Id}", ferramenta);
        });



        app.MapGet("/ferramentas", async (AppDbContext db) =>
        {
            var ferramentas = await db.Ferramentas.ToListAsync();

            return Results.Ok(ferramentas);
        });



        app.MapGet("/ferramentas/{id}", async (int id, AppDbContext db) =>
        {
            var ferramenta = await db.Ferramentas
                .Include(f => f.Funcionario)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (ferramenta is null)
                return Results.NotFound();

            return Results.Ok(new
            {
                ferramenta.Id,
                ferramenta.Nome,
                ferramenta.Descricao,
                ferramenta.Disponivel,
                ferramenta.FuncionarioId,

                Funcionario = ferramenta.Funcionario is null ? null : new
                {
                    ferramenta.Funcionario.Id,
                    ferramenta.Funcionario.Nome,
                    ferramenta.Funcionario.Cargo
                }
            });
        });



        app.MapPut("/ferramentas/{id}", async (int id, Ferramenta dadosAtualizados, AppDbContext db) =>
        {
            var ferramenta = await db.Ferramentas.FindAsync(id);

            if (ferramenta is null)
                return Results.NotFound();

            ferramenta.Nome = dadosAtualizados.Nome;
            ferramenta.Descricao = dadosAtualizados.Descricao;

            await db.SaveChangesAsync();

            return Results.Ok(ferramenta);

        });



        app.MapDelete("/ferramentas/{id}", async (int id, AppDbContext db) =>
        {
            var ferramenta = await db.Ferramentas.FindAsync(id);

            if (ferramenta is null)
                return Results.NotFound();
            db.Ferramentas.Remove(ferramenta);

            await db.SaveChangesAsync();

            return Results.Ok("Ferramenta excluida com sucesso!");


        });


        app.MapPut("/ferramentas/{id}/funcionario", async (
            int id,
            VincularFuncionarioRequest request,
            AppDbContext db) =>
        {
            var ferramenta = await db.Ferramentas.FindAsync(id);

            if (ferramenta is null)
                return Results.NotFound("Ferramenta não encontrada.");

            var funcionario = await db.Funcionarios.FindAsync(request.FuncionarioId);

            if (funcionario is null)
                return Results.NotFound("Funcionário não encontrado.");

            ferramenta.FuncionarioId = request.FuncionarioId;

            ferramenta.Disponivel = false;

            await db.SaveChangesAsync();

            return Results.Ok("Funcionário vinculado com sucesso!");
        });



        app.MapPut("/ferramentas/{id}/devolver", async (int id, AppDbContext db) =>
        {
            var ferramenta = await db.Ferramentas.FindAsync(id);

            if (ferramenta is null)
                return Results.NotFound("Ferramenta não encontrada.");

            if (ferramenta.FuncionarioId is null)
                return Results.BadRequest("Esta ferramenta não está emprestada.");

            ferramenta.FuncionarioId = null;

            ferramenta.Disponivel = true;

            await db.SaveChangesAsync();

            return Results.Ok("Ferramenta devolvida com sucesso!");

        });
    }
}   