function coincidences = find_all_alphabet_coincidences(xors)
	coincidences = {};
	limit = size(xors, 2);
	for i = 1:limit
		coincidences{i} = {};
	endfor
	
	for i = 1:limit
		if (i==limit)
			break;
		endif
		for j = i+1:limit
			coincidences{i}{j} = find_alphabet_coincidences(xors{i}{j});
			coincidences{j}{i} = coincidences{i}{j};
		endfor	
	endfor
endfunction