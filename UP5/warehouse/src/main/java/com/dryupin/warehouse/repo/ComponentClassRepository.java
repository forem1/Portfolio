package com.dryupin.warehouse.repo;

import com.dryupin.warehouse.models.Component_Class;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ComponentClassRepository extends CrudRepository<Component_Class, Long> {
    List<Component_Class> findBycomponentClassName(String name);
}
