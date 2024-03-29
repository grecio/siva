﻿using Dominio;
using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class CruzamentoController : BaseController
    {

        private readonly BLL.BLLCruzamento bpCruzamento;
        private readonly BLL.BLLMunicipio bpMunicipio;

        public CruzamentoController()
        {
            bpCruzamento = new BLL.BLLCruzamento();
            bpMunicipio = new BLL.BLLMunicipio();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Consultar()
        {
            var cruzamentosList = bpCruzamento.RetornarCabecalhoCruzamento();

            var cruzamentosViewModelList = new List<CruzamentoViewModel>();

            if (cruzamentosList.Any())
            {                
                foreach (var item in cruzamentosList)
                {
                    cruzamentosViewModelList.Add(new CruzamentoViewModel() { Cabecalho = item });
                }
            }
                        
            return View(cruzamentosViewModelList);
        }

        [SessionExpire]
        public ActionResult Detalhar(decimal numeroProcesso)
        {

            var cruzamentosDetList = bpCruzamento.RetornarDetalhamentoCruzamento(numeroProcesso);

            var cruzamentosViewModelList = new List<CruzamentoViewModel>();

            if (cruzamentosDetList.Any())
            {
                foreach (var item in cruzamentosDetList)
                {
                    cruzamentosViewModelList.Add(new CruzamentoViewModel() { Detalhamento = item });
                }
            }

            return View(cruzamentosViewModelList);
        }

        [SessionExpire]
        public ActionResult Executar(int CD_CRUZAMENTO, decimal CD_MUNICIPIO, int anoInicial, int anoFinal)
        {
            try
            {
                var processamento = bpCruzamento.ExecutarCruzamento(CD_MUNICIPIO, CD_CRUZAMENTO, anoInicial, anoFinal);

                ShowConfirm(string.Format("O PROCESSO DO CRUZAMENTO DE Nº {0} GERADO COM SUCESSO!\nDESEJA EXIBIR OS DETALHES?", processamento));

                TempData["Processamento"] = processamento;

                return View("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return View("Index");
            }            
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult PreencherTipoCruzamento()
        {
            try
            {
                var tipoCruzamentoList = bpCruzamento.RetornarTipoCruzamento();

                var lista = new ArrayList();

                foreach (var item in tipoCruzamentoList)
                {
                    lista.Add(new { id = item.CD_CRUZAMENTO, text = item.DC_CRUZAMENTO });
                }

                return Json(new { result = "ok", tipoCruzamentoList = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult PreencherMunicipio()
        {
            try
            {

                if (UsuarioLogado == null)
                    throw new Exception("Usuário não está autenticado.");

                var municipioList = bpMunicipio.RetornaMunicipio(UsuarioLogado).ToList();

                var lista = new ArrayList();

                foreach (var item in municipioList)
                {
                    lista.Add(new { id = item.CD_MUNICIPIO_RFB, text = item.NM_MUNICIPIO_RFB });
                }

                return Json(new { result = "ok", municipioList = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

    }
}
