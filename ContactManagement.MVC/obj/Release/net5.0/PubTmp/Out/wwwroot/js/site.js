$(function () {
    $("#ContactType").on('change', function (e) {
        let optionSelected = $("option:selected", this);
        let valueSelected = this.value;

        document.getElementById('Name').value = '';
        document.getElementById('CompanyName').value = '';
        document.getElementById('TradeName').value = '';
        document.getElementById('Cpf').value = '';
        document.getElementById('Cnpj').value = '';
        document.getElementById('Birthday').value = '';
        document.getElementById('Gender').selectedIndex = 0;

        document.getElementById('Name').disabled = (valueSelected == 2);
        document.getElementById('CompanyName').disabled = (valueSelected == 1);
        document.getElementById('TradeName').disabled = (valueSelected == 1);
        document.getElementById('Cpf').disabled = (valueSelected == 2);
        document.getElementById('Cnpj').disabled = (valueSelected == 1);
        document.getElementById('Birthday').disabled = (valueSelected == 2);
        document.getElementById('Gender').disabled = (valueSelected == 2);
    });

    let selectedIndex = document.getElementById('ContactType').selectedIndex;

    document.getElementById('Name').disabled = (selectedIndex <= 0 || selectedIndex == 2);
    document.getElementById('CompanyName').disabled = (selectedIndex <= 0 || selectedIndex == 1);
    document.getElementById('TradeName').disabled = (selectedIndex <= 0 || selectedIndex == 1);
    document.getElementById('Cpf').disabled = (selectedIndex <= 0 || selectedIndex == 2);
    document.getElementById('Cnpj').disabled = (selectedIndex <= 0 || selectedIndex == 1);
    document.getElementById('Birthday').disabled = (selectedIndex <= 0 || selectedIndex == 2);
    document.getElementById('Gender').disabled = (selectedIndex <= 0 || selectedIndex == 2);
});





