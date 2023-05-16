
//URLs
let controller = "/Employee/"
let url_get_all_records = `${controller}GetEmployees`,
    url_get_record_by_id = `${controller}GetEmployeeById`,   //param :id
    url_add_record = `${controller}AddEmployee`,             //param: form data
    url_update_records = `${controller}UpdateEmployee`,   //param: form data
    url_delete_records = `${controller}DeleteEmployee`,   //param: id

    //custom dropdown data lists
    url_get_dataList_departments = '/Common/GetDepartmentDataList',
    url_get_dataList_managers = '/Common/GetEmployeeDataList'


//Data Containers 
//DataList: Contains drodown data for dataList
let data_records,
    data_departments,
    data_managers;

//Form Inputs
let form_id = '#employee-add-update-form',
    txt_emp_id = '#txt-emp-id',
    txt_emp_name = '#txt-emp-name',
    txt_emp_code = '#txt-emp-code',
    txt_designation = '#txt-designation',
    txt_salary = '#txt-salary',
    dataList_manager_id = '#dataList-managers',
    dataList_department_id = '#dataList-departments'

//Other variable
let records_table_id = '#table-employee',
    form_modal_id = '#employee-form-modal',
    form_modal_title = '#employee-form-modal-title'

let dataListControls = [
    {
        DataListUrl: url_get_dataList_departments,
        ControlId: dataList_department_id
    },

    {
        DataListUrl: url_get_dataList_managers,
        ControlId: dataList_manager_id
    },
]




$(document).ready(function () {
    InitializeEmployeeView();
    FlexyForms.InitializeFormStyle(form_id);
})


async function InitializeEmployeeView() {
    await loadRecords();
    await FlexyForms.LoadDataLists(dataListControls)
}


async function loadRecords() {
    $.get(url_get_all_records, function (response) {
        var columns = [
            { data: 'empName' },
            { data: 'empCode' },
            { data: 'designation' },
            { data: 'salary' },
            { data: 'managerName' },
            { data: 'deptName' },
            {
                data: null, render: function (data) {
                    var actionsButtons = `<button onclick="loadEmployeeForm(${data.id})" class="btn btn-sm btn-outline-primary mx-1"><i class="fas fa-user-edit"></i></button>`;
                    actionsButtons += `<button onclick="confirmDelete(${data.id})" class="btn btn-sm btn-outline-danger"><i class="fas fa-user-times"></i></button>`;
                    return actionsButtons;
                }
            },
        ]
        FlexyDataTable.CreateDataTable(records_table_id, response.data, columns);
    })
}


function loadEmployeeForm(id) {
    FlexyForms.ResetForm(form_id);
    $(txt_emp_id).val(id)
    //book_form_modal = new bootstrap.Modal(document.getElementById(book_form_modal_id))
    $(form_modal_title).html('Add New')
    if (id) {
        $.get(url_get_record_by_id, `id=${id}`, function (response) {
            var emp = response.data;
            $(txt_emp_name).val(emp.empName)
            $(txt_emp_code).val(emp.empCode)
            $(txt_designation).val(emp.designation)
            $(txt_salary).val(emp.salary)
            $(dataList_department_id).val(emp.deptId).change()
            $(dataList_manager_id).val(emp.managerId).change()
            $(form_modal_title).html(`Update <span class="text-orange">${emp.empName}</span>`);
        });
    }
    $(form_modal_id).modal('show');
}


function confirmDelete(id) {
    FlexyUtil.ConfirmDialogue('Are you sure to remove this record?', null, function () {
        $.get(url_delete_records, 'id=' + id, function (response) {
            if (response.statusCode === 200) {
                InitializeEmployeeView();
                FlexyUtil.MessageBoxSuccess(response.message, 'Successfull!')
            }
            else if (response.statusCode === 500)
                FlexyUtil.MessageBoxDanger("Something went wrong with the request!", 'Oops!')
            else
                FlexyUtil.MessageBoxDanger(response.message, 'Oops!')
        })
    })
}



$(form_id).unbind().bind('submit', function (e) {
    e.preventDefault();
    var data = new FormData($(form_id)[0]);
    var url = data.get('Id') ? (url_update_records + '?id=' + data.get('Id')) : url_add_record

    $.ajax({
        url: url,
        data: data,
        processData: false,
        contentType: false,
        type: 'POST',
        success: function (response) {
            if (response.statusCode == 200) {
                $(form_modal_id).modal('hide');
                FlexyUtil.MessageBoxSuccess(response.message, 'Great!', InitializeEmployeeView);
            }
            else
                FlexyUtil.MessageBoxDanger(response.message, 'Oops!')

        },
        error: function (response) { console.log(response) }

    });
});


//function validateBookForm() {
//    FlexyForms.ClearValidataionErrors(book_form_id)
//    FlexyForms.BlankInputChecks([txt_book_name, txt_author_name, txt_category_name, txt_language_name, txt_edition])
//    FlexyForms.ValidateInput(txt_edition, !$(txt_edition).val(), 'Edition must be greater than 0');
//    if ($(txt_author_name).val())
//        FlexyForms.ValidateInput(txt_author_name, !(FlexyUtil.IsExistInDataList($(txt_author_name).val(), data_authors)), `'${$(txt_author_name).val()}' will be added as new author!`, 'info');

//    if ($(txt_category_name).val())
//        FlexyForms.ValidateInput(txt_category_name, !(FlexyUtil.IsExistInDataList($(txt_category_name).val(), data_categories)), `'${$(txt_category_name).val()}' will be added as new category!`, 'info');

//    if ($(txt_language_name).val())
//        FlexyForms.ValidateInput(txt_language_name, !(FlexyUtil.IsExistInDataList($(txt_language_name).val(), data_languages)), `'${$(txt_language_name).val()}' will be added as new language!`, 'info');
//    return FlexyForms.FormValidationStatus(book_form_id);
//}

