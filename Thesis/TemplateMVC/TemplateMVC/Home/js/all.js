    function addPatient() {
        $.ajax({
            url: "http://localhost:63440/Home/Create",
            data: {
                qrCode: "barcode4",
                name: "nameSASD",
                age: 123,
                sex: "male",
                address: "address sample",
                phone: "0123445",
                insuranceCode: "insuranceCode sample2"
            },
            success: function(result){            
                if (result) {
                    $('#myModal').modal('toggle');
                } else {
                    $('#myModal').modal('toggle');
                    alert("Failed");
                }
            
            }
        });
    }

    function setVariable(arg) {
        document.getElementById("delPat").value = arg;
    }

    function deletePatient() {    
        $.ajax({
            url: "http://localhost:63440/Home/Delete",
            data: {
                id: document.getElementById("delPat").value
            },
            success: function (result) {
                if (result) {
                    $('#modalDelete').modal('toggle');
                    alert("Deleted");
                    refreshDBPatient();
                } else {
                    $('#modalDelete').modal('toggle');
                    alert("Failed");
                }

            }
        });
    }

    $.ajax({
        url: "http://localhost:63440/Home/getAllPatient",
        success: function (result) {
            var json = JSON.parse(result);
            for (var i in json.pages) {
                dataSet.push([json.pages[i].idPatient, json.pages[i].qrCode, json.pages[i].name, json.pages[i].age, json.pages[i].sex, json.pages[i].address, json.pages[i].phone, json.pages[i].insuranceCode, '<a href="javascript:void(0)" style="margin: 10px" data-toggle="modal" data-target="#modalEdit"><span class="oi oi-circle-check btn-success"></span></a><a href="javascript:void(0)" data-toggle="modal" data-target="#modalDelete" onclick="setVariable(' + json.pages[i].idPatient + ')"><span class="oi oi-circle-x btn-danger"></span></a>']);
            }

        }
    });
    

    $(document).ready(function () {
        //pageIll
        var id_user_patient_update = $('#id_user_patient_update').val();
        
        if (id_user_patient_update) {
            $.ajax({
                url: "http://localhost:63440/Home/getUserById",
                type: 'GET',
                data: {
                    id_user_patient: id_user_patient_update
                },
                success: function (result) {
                    console.log(result)
                    alert(id_user_patient_update)
                    $('#modalEdit').modal('toggle');
                }, error: function (request, status, error) {
                    console.log(error)
                }
            });
        }
    } );