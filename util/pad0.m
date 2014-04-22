function [x1, x2] = pad0(x1, x2)
	if(size(x1, 2) > size(x2, 2))
		[x2, x1] = pad0(x2, x1);
		return
	endif
	
	while (size(x1, 2) < size(x2, 2))
		x1 = [x1, "0"];
	endwhile
endfunction