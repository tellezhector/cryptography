function key = obtain_key_from_spaces(spaces, ciptxt)
	l = 0;
	limit = size(ciptxt, 2);
	for i = 1:limit 
		l = max(l, size(ciptxt{i}, 2));
	endfor
	
	key = repmat("0", 1, 2*l);
	
	for i = 1:limit
		s = spaces{i};
		
		indexes = reshape([s; s], 1, [])(:, 1:size(ciptxt{i}, 2));
		n = sum(indexes')/2;
		hex = repmat("20", 1, n);
		key(:, indexes) = hexxor(ciptxt{i}(:, indexes), hex);
	endfor
endfunction
