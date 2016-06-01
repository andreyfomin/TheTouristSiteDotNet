function UserValueKeyPress() {

    setTimeout(
        function () {
            var edValue = document.getElementById("TextBoxUser");
            var beforeVal = edValue.value;
            // debugger;
            if (/^[a-z|A-Z]{1,3}$/.test(beforeVal)) {
                document.getElementById("TextBoxUserError").innerHTML = "";
            } else {
                document.getElementById("TextBoxUserError").innerHTML = "*";
                document.getElementById("SignUpButton").disabled=true;
            }

        }, 0
    );
    }

        function EmailValueKeyPress() {
        setTimeout(
        function () {
            var edValue = document.getElementById("TextBoxEmail");
            var beforeVal = edValue.value;
            // debugger;
            if (/^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/i.test(beforeVal)) {
                document.getElementById("TextBoxEmailError").innerHTML = "";
            } else {
                document.getElementById("TextBoxEmailError").innerHTML = "*";
                document.getElementById("SignUpButton").disabled=true;
            }

        }, 0
    );
    }

       function PhoneValueKeyPress() {
        
        setTimeout(
        function () {
            var edValue = document.getElementById("TextBoxPhone");
            var beforeVal = edValue.value;
            // debugger;
            if (/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/.test(beforeVal)) {
                document.getElementById("TextBoxUserError").innerHTML = "";
            } else {
                document.getElementById("TextBoxUserError").innerHTML = "*";
            }

        }, 0
    );
    }

    function FNameValueKeyPress() {
       
        setTimeout(
        function () {
            var edValue = document.getElementById("TextBoxFName");
            var beforeVal = edValue.value;
            // debugger;
            if (/^ [A-z\s\-\.]*/.test(beforeVal)) {
                document.getElementById("TextBoxFNameError").innerHTML = "";
            } else {
                document.getElementById("TextBoxFNameError").innerHTML = "*";
                 document.getElementById("SignUpButton").disabled=true;
            }

        }, 0
    );
    }

        function LNameValueKeyPress() {
        
        setTimeout(
        function () {
            var edValue = document.getElementById("TextBoxLName");
            var beforeVal = edValue.value;
            // debugger;
            if (/^ [A-z\s\-\.]*/.test(beforeVal)) {
                document.getElementById("TextBoxLNameError").innerHTML = "";
            } else {
                document.getElementById("TextBoxLNameError").innerHTML = "*";
                 document.getElementById("SignUpButton").disabled=true;
            }

        }, 0
    );
    }


}