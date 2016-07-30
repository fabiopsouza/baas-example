package br.ung.tccweb.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class Movimentacao implements Serializable {

	private static final long serialVersionUID = -2054841158239609214L;
	
	private Integer Id;
	private String Cpf;
	private String NomeTitular;
	private String NumeroConta;
	private String TotalCreditos;
	private String TotalDebitos;
	private Integer StatusMovimentacaoId;

	public Movimentacao(){
		
	}
	
	@JsonProperty("Id")
	public Integer getId() {
		return Id;
	}

	public void setId(Integer id) {
		Id = id;
	}

	@JsonProperty("Cpf")
	public String getCpf() {
		return Cpf;
	}

	public void setCpf(String cpf) {
		Cpf = cpf;
	}

	@JsonProperty("NomeTitular")
	public String getNomeTitular() {
		return NomeTitular;
	}

	public void setNomeTitular(String nomeTitular) {
		NomeTitular = nomeTitular;
	}

	@JsonProperty("NumeroConta")
	public String getNumeroConta() {
		return NumeroConta;
	}

	public void setNumeroConta(String numeroConta) {
		NumeroConta = numeroConta;
	}

	@JsonProperty("TotalCreditos")
	public String getTotalCreditos() {
		return TotalCreditos;
	}

	public void setTotalCreditos(String totalCreditos) {
		TotalCreditos = totalCreditos;
	}

	@JsonProperty("TotalDebitos")
	public String getTotalDebitos() {
		return TotalDebitos;
	}

	public void setTotalDebitos(String totalDebitos) {
		TotalDebitos = totalDebitos;
	}

	@JsonProperty("StatusMovimentacaoId")
	public Integer getStatusMovimentacaoId() {
		return StatusMovimentacaoId;
	}

	public void setStatusMovimentacaoId(Integer statusMovimentacaoId) {
		StatusMovimentacaoId = statusMovimentacaoId;
	}
}
