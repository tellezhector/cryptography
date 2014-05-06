function [IV, ct] = extract_IV(cct)
	IV = cct(1:32);
	ct = cct(33:end);
endfunction