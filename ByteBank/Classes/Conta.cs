﻿using ByteBank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Classes {
    public class Conta : Banco, IConta {

        public Conta() {
            this.NumeroDaAgencia = "0001";
            Conta.NumeroDaContaSequencial++;
            this.Movimentacoes = new List<Extrato>();
        }

        public double Saldo { get; protected set; }
        public string NumeroDaConta { get; protected set; }
        public string NumeroDaAgencia { get; private set; }
        public static int NumeroDaContaSequencial { get; private set; }
        private List<Extrato> Movimentacoes;
        public void Deposita(double valor) {
            DateTime DataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(DataAtual, "Deposito", valor));
            this.Saldo += valor;
        }
        public bool Saca(double valor) {
            if (valor > this.SaldoDisponível()) {
                Console.WriteLine("Saldo indisponível");
                return false;
            }
            DateTime DataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(DataAtual, "Saque", -valor));
            this.Saldo -= valor;
            return true;

        }
        public double SaldoDisponível() {
            return this.Saldo;
        }

        public string GetCodigoDoBanco() {
            return this.CoodigoDoBanco;
        }

        public string GetNumeroDaConta() {
            return this.NumeroDaConta;
        }

        public string GetNumeroAgencia() {
            return this.NumeroDaAgencia;
        }

        public List<Extrato> Extrato() {
            return this.Movimentacoes;
        }
    }
}