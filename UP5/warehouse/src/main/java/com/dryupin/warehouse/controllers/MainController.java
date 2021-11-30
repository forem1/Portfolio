package com.dryupin.warehouse.controllers;

import com.dryupin.warehouse.models.*;
import com.dryupin.warehouse.repo.ComponentCategoryRepository;
import com.dryupin.warehouse.repo.ComponentClassRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.validation.ObjectError;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.validation.Valid;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Controller
public class MainController {
    @Autowired
    private ComponentClassRepository ComponentClassRepository;
    @Autowired
    private com.dryupin.warehouse.repo.ComponentCategoryRepository ComponentCategoryRepository;
    @Autowired
    private com.dryupin.warehouse.repo.ComponentGroupRepository ComponentGroupRepository;
    @Autowired
    private com.dryupin.warehouse.repo.ComponentRepository ComponentRepository;
    @Autowired
    private com.dryupin.warehouse.repo.TransactionRepository TransactionRepository;
    @Autowired
    private com.dryupin.warehouse.repo.StaffRepository StaffRepository;

    @GetMapping("/")
    public String warehouseMain(Model model) {
        String Tree = "";
        String SelectCategory = "";
        String SelectGroup = "";
        String SelectComponent = "";
        String SelectStaff = "";

        Iterable<Component_Class> ComponentClass = ComponentClassRepository.findAll();
        for(var CompClass : ComponentClass) {
            SelectCategory += "<option value='" + CompClass.getId() + "'>" + CompClass.getComponentClassName() + "</option>";

            Tree += "<li>" + CompClass.getComponentClassName();
            Iterable<Component_Category> ComponentCategory = ComponentCategoryRepository.GetComponentCategoryByClassId(CompClass.getId().toString());
            for (var CompCategory : ComponentCategory) {
                SelectGroup += "<option value='" + CompCategory.getId() + "'>" + CompClass.getComponentClassName() + "." + CompCategory.getComponentCategoryName() + "</option>";

                Tree += "<ul>";
                Tree += "<li>" + CompCategory.getComponentCategoryName();
                Iterable<Component_Group> ComponentGroup = ComponentGroupRepository.GetComponentGroupByCategoryId(CompCategory.getId().toString());
                for (var CompGroup : ComponentGroup) {
                    SelectComponent += "<option value='" + CompGroup.getId() + "'>" + CompClass.getComponentClassName() + "." + CompCategory.getComponentCategoryName() + "." + CompGroup.getComponentGroupName() + "</option>";

                    Tree += "<ul>";
                    Tree += "<li>" + CompGroup.getComponentGroupName();
                    Iterable<Component> Component = ComponentRepository.GetComponentByGroupId(CompGroup.getId().toString());
                    for (var CompComponent : Component) {
                        Tree += "<ul>";
                        Tree += "<li><a data-toggle='modal' data-target='#ComponentInfo_" + CompComponent.getId() + "'>" + CompComponent.getComponentName() + "</a></li>";

                        Tree += "<div class='modal fade component-info' id='ComponentInfo_" + CompComponent.getId() + "' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'>";
                        Tree += "  <div class='modal-dialog modal-dialog-centered' role='document'>";
                        Tree += "    <div class='modal-content'>";
                        Tree += "      <div class='modal-header'>";
                        Tree += "        <h5 class='modal-title' id='exampleModalLabel'>" + CompComponent.getComponentName() + "</h5>";
                        Tree += "      </div>";
                        Tree += "      <div class='modal-body'>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Id</label><label>" + CompComponent.getId() + "</label><br>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Наименование</label><input class='modal-parameter-input' id='ComponentFieldName_" + CompComponent.getId() + "' value='" + CompComponent.getComponentName() + "'><br>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Полное наименование</label><input class='modal-parameter-input' id='ComponentFieldFullName_" + CompComponent.getId() + "' value='" + CompComponent.getComponentFullName() + "'><br>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Серийный номер</label><input class='modal-parameter-input' id='ComponentFieldSerial_" + CompComponent.getId() + "' value='" + CompComponent.getComponentSerial() + "'><br>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Количество</label><input class='modal-parameter-input' id='ComponentFieldAmount_" + CompComponent.getId() + "' value='" + CompComponent.getComponentAmount() + "'><input class='modal-parameter-input' style='width: 125px;' id='ComponentFieldUnit_" + CompComponent.getId() + "' value='" + CompComponent.getComponentUnit() + "'><br>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Расположение</label><input class='modal-parameter-input' id='ComponentFieldLocation_" + CompComponent.getId() + "' value='" + CompComponent.getComponentLocation() + "'><br>";
                        Tree += "        <label style='font-weight: normal; padding-right: 10px;'>Тег</label><input class='modal-parameter-input' id='ComponentFieldTag_" + CompComponent.getId() + "' value='" + CompComponent.getComponentTag() + "'><br>";
                        Tree += "      </div>";
                        Tree += "      <div class='modal-footer'>";
                        Tree += "        <button type='button' style='left:15px; position:absolute;' id='ComponentInfoDelete_" + CompComponent.getId() + "' class='btn btn-danger component-info-delete'>Удалить</button>";
                        Tree += "        <button type='button' id='ComponentInfoSave_" + CompComponent.getId() + "' class='btn btn-primary component-info-save'>Сохранить</button>";
                        Tree += "        <button type='button' id='TransactionAdd_" + CompComponent.getId() + "' class='btn btn-info transaction-add' data-toggle='modal' data-target='#TransactionAdd'>Транзакция</button>";
                        Tree += "        <button type='button' class='btn btn-secondary' data-dismiss='modal'>Закрыть</button>";
                        Tree += "      </div>";
                        Tree += "    </div>";
                        Tree += "</div>";
                        Tree += "</ul>";
                    }
                    Tree += "</li>";
                    Tree += "</ul>";
                }
                Tree += "</li>";
                Tree += "</ul>";
            }
            Tree += "</li>";
        }

        Iterable<Staff> Staff = StaffRepository.findAll();
        for(var StaffIterables : Staff) {
        SelectStaff+="<option value='" + StaffIterables.getId() + "'>"+StaffIterables.getName()+" "+StaffIterables.getPatronymic()+" "+StaffIterables.getSurname()+"</option>";
        }

        System.out.println(Tree);
        Iterable<Component_Class> Comclass = ComponentClassRepository.findAll();

        model.addAttribute("ComponentsTree", Tree);
        model.addAttribute("SelectCategory", SelectCategory);
        model.addAttribute("SelectGroup", SelectGroup);
        model.addAttribute("SelectComponent", SelectComponent);
        model.addAttribute("SelectStaff", SelectStaff);
        model.addAttribute("component_class", Comclass);

        return "Warehouse";
    }

    @GetMapping("/AddComponent")
    public String AddComponent(@RequestParam String ComponentGroup, @RequestParam String ComponentName, @RequestParam String ComponentFullName, @RequestParam String ComponentSerial, @RequestParam String ComponentAmount, @RequestParam String ComponentUnit, @RequestParam String ComponentLocation, @RequestParam String ComponentTag) {
        Component component = new Component(ComponentName, ComponentFullName, ComponentSerial, ComponentUnit, ComponentTag, ComponentGroup, ComponentAmount, ComponentLocation);
        ComponentRepository.save(component);
        return "Warehouse";
    }

    @GetMapping("/UpdateComponent")
    public String UpdateComponent(@RequestParam Long ComponentId, @RequestParam String ComponentName, @RequestParam String ComponentFullName, @RequestParam String ComponentSerial, @RequestParam String ComponentAmount, @RequestParam String ComponentUnit, @RequestParam String ComponentLocation, @RequestParam String ComponentTag) {
        Component component = ComponentRepository.findById(ComponentId).orElseThrow();
        component.setComponentName(ComponentName);
        component.setComponentFullName(ComponentFullName);
        component.setComponentSerial(ComponentSerial);
        component.setComponentAmount(ComponentAmount);
        component.setComponentUnit(ComponentUnit);
        component.setComponentLocation(ComponentLocation);
        component.setComponentTag(ComponentTag);
        ComponentRepository.save(component);
        return "Warehouse";
    }

    @GetMapping("/DeleteComponent")
    public String DeleteComponent(@RequestParam Long ComponentId) {
        Component component = ComponentRepository.findById(ComponentId).orElseThrow();
        ComponentRepository.delete(component);
        return "Warehouse";
    }

    @GetMapping("/AddClass")
    public String AddClass(@Valid Component_Class Component_Class, BindingResult bindingResult, @RequestParam String ClassName) {
        List<Component_Class> res = ComponentClassRepository.findBycomponentClassName(ClassName);
        if(res.size()>0) {
            ObjectError error = new ObjectError("title", "Такой класс уже есть");
            bindingResult.addError(error);
            return "Warehouse";
        }

        Component_Class componentClass = new Component_Class(ClassName);
        ComponentClassRepository.save(componentClass);
        return "Warehouse";
    }

    @GetMapping("/AddCategory")
    public String AddCategory(@RequestParam String CategoryName, @RequestParam String CategoryClass) {
        Component_Category componentCategory = new Component_Category(CategoryName, CategoryClass);
        ComponentCategoryRepository.save(componentCategory);
        return "Warehouse";
    }

    @GetMapping("/AddGroup")
    public String AddGroup(@RequestParam String GroupName, @RequestParam String GroupCategory) {
        Component_Group componentGroup = new Component_Group(GroupCategory, GroupName);
        ComponentGroupRepository.save(componentGroup);
        return "Warehouse";
    }

    @GetMapping("/AddTransaction")
    public String AddTransaction(@RequestParam String TransactionComponentId, @RequestParam String TransactionDate, @RequestParam String TransactionDifferent, @RequestParam String TransactionStaffId, @RequestParam String TransactionPlace, @RequestParam String TransactionNote) {
        Transaction transaction = new Transaction(TransactionComponentId, TransactionDate, TransactionDifferent, TransactionStaffId, TransactionPlace, TransactionNote);
        TransactionRepository.save(transaction);
        Component component = ComponentRepository.findById(Long.parseLong(TransactionComponentId)).orElseThrow();
        int NewAmount = Integer.parseInt(component.getComponentAmount()) + Integer.parseInt(TransactionDifferent);
        component.setComponentAmount(String.valueOf(NewAmount));
        ComponentRepository.save(component);
        return "Warehouse";
    }

    @GetMapping("/GetTransactions")
    @ResponseBody
    public String GetTransactions() {
        String JSON = "[";
        int i=0;

        Iterable<Transaction> Transactions = TransactionRepository.GetAll();
        for(var TransactionsList : Transactions) {

            JSON+="{\"id\":\""+TransactionsList.getId()+"\",";
            JSON+="\"ComponentName\":\""+TransactionsList.getComponentId()+"\",";
            JSON+="\"StaffName\":\""+TransactionsList.getStaffId()+"\",";
            JSON+="\"TransactionDate\":\""+TransactionsList.getDate()+"\",";
            JSON+="\"TransactionDifferent\":\""+TransactionsList.getDifferent()+"\",";
            JSON+="\"TransactionPlace\":\""+TransactionsList.getPlace()+"\",";
            JSON+="\"TransactionNote\":\""+TransactionsList.getNote()+"\"}";
            if(i++ < Transactions.spliterator().getExactSizeIfKnown()-1){
                JSON+=",";
            }
        }
        JSON+="]";
        System.out.println(JSON);
        return JSON;
    }


    /*TODO
     */
}
