package br.ung.tccweb.util;

import java.text.ParseException;

import javax.swing.text.MaskFormatter;

public class Formatter {

	public static String cpf(String cpf) throws ParseException{
		MaskFormatter mask = new MaskFormatter("###.###.###-##");
        mask.setValueContainsLiteralCharacters(false);
        return mask.valueToString(cpf);
	}
	
}
