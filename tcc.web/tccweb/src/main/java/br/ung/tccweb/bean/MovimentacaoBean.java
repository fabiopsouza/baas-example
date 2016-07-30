package br.ung.tccweb.bean;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;

import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.context.FacesContext;

import br.ung.tccweb.model.Movimentacao;
import br.ung.tccweb.model.Response;
import br.ung.tccweb.model.StatusMovimentacao;
import br.ung.tccweb.proxy.HttpProxy;
import br.ung.tccweb.util.Formatter;

@ManagedBean(name="movimentacaoBean")
public class MovimentacaoBean {

	FacesContext context = FacesContext.getCurrentInstance();
	
	private List<Movimentacao> list = null;
	private List<StatusMovimentacao> statusList = null;
	private Integer status = null;

	@SuppressWarnings("unchecked")
	public List<Movimentacao> getList() {
		
		if(list == null){
			HttpProxy proxy = new HttpProxy();
			
			try {
				String api = "movimentacao" + (status != null && status > 0 ? "/status/" + status : "");
				
				Response response = proxy.get(api, list);

				if(response.isIsSuccess())
					list = (List<Movimentacao>)response.getData();
								
			} catch (Exception e) {
		        context.addMessage(null, new FacesMessage("Error",  e.getMessage()));
			}
		}
		
		return list != null ? list : new ArrayList<Movimentacao>();
	}

	public void setList(List<Movimentacao> list) {
		this.list = list;
	}

	public List<StatusMovimentacao> getStatusList(){
		
		if(statusList == null){
			statusList = new ArrayList<StatusMovimentacao>();
			statusList.add(new StatusMovimentacao(1, "Pendente"));
			statusList.add(new StatusMovimentacao(2, "Aprovado"));
			statusList.add(new StatusMovimentacao(3, "Reprovado"));
		}
		
		return statusList != null ? statusList : new ArrayList<StatusMovimentacao>();
	}
	
	public void setStatusList(List<StatusMovimentacao> statusList) {
		this.statusList = statusList;
	}
	
	public Integer getStatus() {
		return status;
	}

	public void setStatus(Integer status) {
		list = null;
		this.status = status;
	}
	
	public String getStatusDescricao(Integer id){
		if(id == 1)
			return "Pendente";
		else if(id == 2)
			return "Aprovado";
		else if(id == 3)
			return "Reprovado";
		else
			return "-";
	}
	
	public String getStatusCor(Integer id){
		if(id == 1) //Pendente
			return "#886aea";
		else if(id == 2) //Aprovado
			return "#33cd5f";
		else if(id == 3) //Reprovado
			return "#ef473a";
		else
			return "black";
	}
	
	public String getCpfFormatted(String cpf){
		if (cpf == null) 
			return "-";
		
		try {
			return Formatter.cpf(cpf.toString());
		} catch (ParseException e) {
			return "-";
		}

	}
	
	public void aprovar(String id){
		if(id != null){
			HttpProxy proxy = new HttpProxy();
			try {
				proxy.post("movimentacao/aprovar/" + id);
				list = null;
			} catch (Exception e) {
				context.addMessage(null, new FacesMessage("Error",  e.getMessage()));
			}
		}
	}
	
	public void reprovar(String id){
		if(id != null){
			HttpProxy proxy = new HttpProxy();
			try {
				proxy.post("movimentacao/reprovar/" + id);
				list = null;
			} catch (Exception e) {
				context.addMessage(null, new FacesMessage("Error",  e.getMessage()));
			}
		}
	}
	
	public void excluir(String id){
		if(id != null){
			HttpProxy proxy = new HttpProxy();
			try {
				proxy.post("movimentacao/delete/" + id);
				list = null;
			} catch (Exception e) {
				context.addMessage(null, new FacesMessage("Error",  e.getMessage()));
			}
		}
	}

}
