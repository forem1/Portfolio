package com.dryupin.warehouse.repo;

import com.dryupin.warehouse.models.Component_Category;
import com.dryupin.warehouse.models.Component_Class;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

public interface ComponentCategoryRepository extends CrudRepository<Component_Category, Long> {
    @Query("select c from Component_Category c where c.componentCategoryClassId = :#{#ClassId}")
    Iterable<Component_Category> GetComponentCategoryByClassId(@Param("ClassId") String ClassId);
}
