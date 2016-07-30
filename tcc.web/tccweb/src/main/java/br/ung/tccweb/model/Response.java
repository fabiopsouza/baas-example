package br.ung.tccweb.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class Response implements Serializable {

	private static final long serialVersionUID = -4867664725086682780L;
	
	private boolean IsSuccess;
	private String Error;
	private Object Data;
	private Integer Code;
	
	public Response(){
		
	}
	
	@JsonProperty("IsSuccess")
	public boolean isIsSuccess() {
		return IsSuccess;
	}

	public void setIsSuccess(boolean isSuccess) {
		IsSuccess = isSuccess;
	}

	@JsonProperty("Error")
	public String getError() {
		return Error;
	}

	public void setError(String error) {
		Error = error;
	}

	@JsonProperty("Data")
	public Object getData() {
		return Data;
	}

	public void setData(Object data) {
		Data = data;
	}

	@JsonProperty("Code")
	public Integer getCode() {
		return Code;
	}

	public void setCode(Integer code) {
		Code = code;
	}

	@Override
	public String toString() {
		return "Response [IsSuccess=" + IsSuccess + ", Error=" + Error + ", Data=" + Data + ", Code=" + Code + "]";
	}

}
