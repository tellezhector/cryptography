function coincidence_matrix = get_coincidences_matrix(i, coincidences)
		limit = size(coincidences{i}, 2);
		coincidence_matrix = [];
		
		for j = 1:limit
			if (i==j)
				continue;
			endif
			
			if(isequal(coincidence_matrix, []))
				coincidence_matrix = [coincidence_matrix; coincidences{i}{j}];
				coincidence_matrix
				continue;
			endif
			
			[coincidence_matrix, aux] = even_up_with_numeric_0_to_the_right(coincidence_matrix, coincidences{i}{j});
			coincidence_matrix = [coincidence_matrix; aux];			
		endfor
endfunction