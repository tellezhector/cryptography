function text = hex2txt(hex)
	pairs = split_hex_in_pairs(hex);
	text = char(hex2dec(pairs))';	
endfunction