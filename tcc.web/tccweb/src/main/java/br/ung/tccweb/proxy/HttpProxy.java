package br.ung.tccweb.proxy;

import java.util.List;

import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;

import br.ung.tccweb.model.Response;

@Service
public class HttpProxy{

	final String uri = "http://localhost:8083/api/";
	
	RestTemplate rest = new RestTemplate();
	
	ObjectMapper mapper = new ObjectMapper();
	
	public HttpProxy(){
		
	}
	
	public <T> Response get(String api, T returnType) throws Exception{
		Response response = rest.getForObject(uri + api, Response.class);
		
		String json = mapper.writeValueAsString(response.getData());
		
		TypeReference<T> type = new TypeReference<T>(){};
		List<T> list = mapper.readValue(json, type);
		response.setData(list);
		
		return response;
	}
	
	public Response post(String api) throws Exception{
		return rest.postForObject(uri + api, null, Response.class);
	}
	
}
