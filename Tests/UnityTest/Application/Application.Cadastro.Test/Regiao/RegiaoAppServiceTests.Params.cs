using System;
using System.Collections.Generic;
using RegiaoDomain = Domain.Cadastro.Regiao;

namespace Application.Cadastro.Test.Regiao;

public partial class RegiaoAppServiceTests
{
    public static IEnumerable<object[]> ParamsRegioesFiltros()
    {
        var regiaoId1 = Guid.NewGuid();
        var nome1 = "Norte";
        var sigla1 = "N";
        var regiao1 = RegiaoFactory.GerarRegiao(regiaoId1, nome1, sigla1);
        
        var regiaoId2 = Guid.NewGuid();
        var nome2 = "Sul";
        var sigla2 = "S";
        var regiao2 = RegiaoFactory.GerarRegiao(regiaoId2, nome2, sigla2);
        
        var regiaoId3 = Guid.NewGuid();
        var nome3= "Sudeste";
        var sigla3 = "SE";
        var regiao3 = RegiaoFactory.GerarRegiao(regiaoId3, nome3, sigla3);
        
        yield return
        [
            new List<RegiaoDomain> { regiao1, regiao2, regiao3 },
            RegiaoFactory.GerarRegiaoFiltroViewModel([regiaoId1, regiaoId3]),
            new List<RegiaoDomain> {regiao1, regiao3},
            2
        ];

        yield return
        [
            new List<RegiaoDomain> { regiao1, regiao2, regiao3 },
            RegiaoFactory.GerarRegiaoFiltroViewModel(sigla: sigla1),
            new List<RegiaoDomain> {regiao1},
            1
        ];
        
        yield return
        [
            new List<RegiaoDomain> { regiao1, regiao2, regiao3 },
            RegiaoFactory.GerarRegiaoFiltroViewModel(nome: nome2),
            new List<RegiaoDomain> {regiao2},
            1
        ];
        
        yield return
        [
            new List<RegiaoDomain> { regiao1, regiao2, regiao3 },
            RegiaoFactory.GerarRegiaoFiltroViewModel([regiaoId1]),
            new List<RegiaoDomain> {regiao1},
            1
        ];
    }
}