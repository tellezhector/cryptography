function coincidences = find_alphabet_coincidences(hex)
	alph = get_alphabet_hex();
	pairs = split_hex_in_pairs(hex);	
	
	alph_dec = hex2dec(alph);
	pairs_dec = hex2dec(pairs);
	s = size(pairs_dec, 1);
	coincidences = [];
	for i = 1:s
		if(sum(alph_dec == pairs_dec(i)) == 1)
			coincidences = [coincidences, 1];
			continue;
		endif
		
		coincidences = [coincidences, 0];
	endfor
endfunction