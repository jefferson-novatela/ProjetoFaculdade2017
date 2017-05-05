
$(document).ready(function () {

	$('#VlrProduto').change(function () {
		somenteNumeros(this);
		calcula();
	});

	$('#Quantidade').change(function () {
		calcula();
	});
	//$('#VlrProduto').mask('999');
	//$('#Quantidade').mask('')

	
});

function somenteNumeros(num) {
	var er = /[^0-9.,]/;
	er.lastIndex = 0;
	var campo = num;
	if (er.test(campo.value)) {
		campo.value = "";
	}
}

function calcula() {
	var valorProd = parseInt($('#VlrProduto').val());
	var qtdProd = $('#Quantidade').val();
	var result = valorProd * qtdProd;

	$('#Valor').val(result);
	
	$('#Quantidade').val(qtdProd);
}