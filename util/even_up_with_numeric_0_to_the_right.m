function [x1, x2] = even_up_with_numeric_0_to_the_right(x1, x2)
	if(size(x1, 2) > size(x2, 2))
		[x2, x1] = even_up_with_numeric_0_to_the_right(x2, x1);
		return
	endif
	
	if (size(x1, 2) < size(x2, 2))
		diff = size(x2, 2) - size(x1, 2);
		mat = zeros(size(x1, 1), diff);
		x1 = [x1, mat];
	endif
endfunction