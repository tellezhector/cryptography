function spaces = find_spaces_in_ciphertext(coincidences)
	spaces = {};
	limit = size(coincidences, 2);
	
	for i = 1:limit
		coincidences_matrix = get_coincidences_matrix(i, coincidences);
		spaces{i} = sum(coincidences_matrix) > 8;
	endfor	
endfunction