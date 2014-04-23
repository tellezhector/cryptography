function xors = get_xors(ciptxt)
	xors = {};
	limit = size(ciptxt, 2);
	for i = 1:limit
		xors{i} = {};
	endfor
	
	for i = 1:limit
		if (i==limit)
			break;
		endif
		"working...";
		for j = i+1:limit
			xors{i}{j} = hexxor(ciptxt{i}, ciptxt{j});
			xors{j}{i} = xors{i}{j};
		endfor	
	endfor
endfunction