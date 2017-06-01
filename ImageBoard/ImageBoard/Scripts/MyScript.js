    flag = true;
    function dawn(input) {
        input.value = input.value != 'Зарегистрироваться' ? 'Зарегистрироваться' : 'Перейти к Авторизации'
        flag = flag != true ? true : false;
        if (!flag) {
            $("#formAuth").hide(200, function () { $("#formSignup").show(200, function () { $("#box_user").animate({ height: 500 }, 100) }); });
        }
        else {
            $("#formSignup").hide(200, function () { $("#formAuth").show(200, function () { $("#box_user").animate({ height: 350 }, 100) }); });
        }
    }